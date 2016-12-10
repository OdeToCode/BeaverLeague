import axios, { AxiosResponse } from "axios";
import { IGolfer } from "models"
import { errorHandler } from "./error";

const XSRF_TOKEN_KEY = "xsrfToken";
const XSRF_TOKEN_NAME_KEY = "xsrfTokenName";

function reportError(message: string, response: AxiosResponse) {
    const formattedMessage = `${message} : Status ${response.status} ${response.statusText}`
    errorHandler.reportMessage(formattedMessage);
}

function setToken({token, tokenName}: { token: string, tokenName: string }) {
    window.sessionStorage.setItem(XSRF_TOKEN_KEY, token);
    window.sessionStorage.setItem(XSRF_TOKEN_NAME_KEY, tokenName);
    axios.defaults.headers.common[tokenName] = token;
}

function initializeXsrfToken() {
    let token = window.sessionStorage.getItem(XSRF_TOKEN_KEY);
    let tokenName = window.sessionStorage.getItem(XSRF_TOKEN_NAME_KEY);

    if (!token || !tokenName) {
        axios.get("/api/xsrfToken")
            .then(r => setToken(r.data))
            .catch(r => reportError("Could not fetch XSRFTOKEN", r));
    } else {
        setToken({ token: token, tokenName: tokenName });
    }
}

initializeXsrfToken();

class Api {

    async getAllGolfers() {        
        try {
            let response = await axios.get("/api/golfers");
            return response.data as IGolfer[];            
        }
        catch(err) {
            reportError("Could not fetch all golfers", err.response);
        }      
    }

    async getActiveGolfers() {
        try {
            let response = await axios.get("/api/golfers/active");
            return response.data as IGolfer[];
        }
        catch(err) {
            reportError("Could not fetch active golfers", err.response);
        }        
    }

    async setGolferActiveFlag(data: { id: number, value: boolean }, name: string) {
        try {
            let result = await axios.post(`/api/golfers/${data.id}/activeflag`, data);
            return result;
        }
        catch(err) {
            reportError(`Could not update active flag for ${name}`, err.response);
        }
    }
}

export const api = new Api();