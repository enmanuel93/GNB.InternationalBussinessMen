import axios from "axios";

export const axiosConnection = axios.create({
    baseURL: process.env.REACT_APP_BASE_URL,
});