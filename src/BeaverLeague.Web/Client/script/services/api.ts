import axios, { AxiosResponse } from "axios";
import { IGolfer, IMatchSet } from "models"
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

const axiosExec = async function<T>(f:() => T, message: string) {
    try{
        return await f();
    }
    catch(err){
        reportError(`Operation Failed: ${message}`, err.response);
        throw err;
    }
};

class Api {

    async getAllGolfers() {     
        return axiosExec(async () => {
            let response = await axios.get("/api/golfers");
            return response.data as IGolfer[];
        }, "Fetch all golfers");
    }

    async getActiveGolfers() {
        return axiosExec(async () => {
            let response = await axios.get("/api/golfers/active");
            return response.data as IGolfer[];
        }, "Get active golfers");       
    }

    async setGolferActiveFlag(data: { id: number, value: boolean }, name: string) {
        return axiosExec(async () => {
            let response = await axios.post(`/api/golfers/${data.id}/activeflag`, data);
            return response.data;
        }, `Setting update flag for ${name}`);          
    }

    async getMatchSet(id: number) {
        return axiosExec(async () => {
            let result = await axios.get(`/api/matchset/${id}`);
            return result.data as IMatchSet;
        }, `Fetch matchset ${id}`);                       
    }
}

export const api = new Api();