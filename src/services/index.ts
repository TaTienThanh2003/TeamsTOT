import axios from "axios"
const api = import.meta.env.VITE_API_BACKEND_URL;

export const UserLogin = async (email: string, password: string) => {
    const res = await axios.post(`${api}/users/signin`, {
        email,
        password
    });
    return res.data;
}

export const UserSignin = async (email: string, password: string) => {
    const res = await axios.post(`${api}/users/signin`, {
        email,
        password
    });
    return res.data;
}


export const getCourses = async () => {
    const res = await axios.get(`${api}/courses`)
    return res.data
}