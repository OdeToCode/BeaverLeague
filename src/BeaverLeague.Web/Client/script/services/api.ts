import axios, {AxiosResponse} from "axios";
import {errorHandler} from "./error";

const XSRF_TOKEN_KEY = "xsrfToken";
const XSRF_TOKEN_NAME_KEY = "xsrfTokenName";

function reportError(message: string, response: AxiosResponse)  {
    const formattedMessage = `${message} : Status ${response.status} ${response.statusText}`
    errorHandler.reportMessage(formattedMessage);
}

function setToken({token, tokenName}: {token: string, tokenName: string}) {
    window.sessionStorage.setItem(XSRF_TOKEN_KEY, token);
    window.sessionStorage.setItem(XSRF_TOKEN_NAME_KEY, tokenName); 
    axios.defaults.headers.common[tokenName] = token;
}

function initializeXsrfToken() {
    let token = window.sessionStorage.getItem(XSRF_TOKEN_KEY);
    let tokenName = window.sessionStorage.getItem(XSRF_TOKEN_NAME_KEY);

    if(!token || !tokenName) {
        axios.get("/api/xsrfToken")
             .then(r => setToken(r.data))
             .catch(r => reportError("Could not fetch XSRFTOKEN", r));             
    } else {
        setToken({token: token, tokenName: tokenName});
    }
}

initializeXsrfToken();

class Api {

    getAllGolfers() {
        return  axios.get("/api/golfers")
                     .then(r => r.data, 
                           r => reportError("Could not fetch golfers", r));
    }

    setGolferActiveFlag(data: {id:number, value: boolean}, name: string) {
        axios.post("/api/golfers/activeflag", data)
             .then(null, r => reportError(`Could not update active flag for ${name}`, r));             
    }
}

export const api = new Api();