import axios from "axios"
const api = import.meta.env.VITE_API_BACKEND_URL;
export const login = async (email: string, password: string) => {
    try {
        const res = await axios.post(`${api}/users/signin`, {
            email,
            password,
        }
    );
        localStorage.setItem("userId", res.data.id);
        return { success: true, id: res.data.id, data: res.data};
    } catch (err: any) {
        return { success: false, error: err.response?.data || "Đăng nhập thất bại" };
    }
};

export const register = async (username:string, email: string, password: string) => {
    try {
        const res = await axios.post(`${api}/users/signup`, {
            username,
            email,
            password,
        });
        return { success: true, data: res.data };
    } catch (err: any) {
        return { success: false, error: err.response?.data || "Đăng ký thất bại" };
    }
};

export const getCourses = async () => {
    const res = await axios.get(`${api}/courses`)
    return res.data
};
export const getTeacher = async() => {
    const res = await axios.get(`${api}/users/getTeacher`)
    return res.data
}
export const getCourseById = async (id: number) => {
    const res = await axios.get(`${api}/courses/${id}`)
    return res.data
}       
export const getCourseByName = async (name: string) => {
    const encodedName = encodeURIComponent(name);
    const res = await axios.get(`${api}/courses/name?name=${encodedName}`);
    return res.data;
};    
export const getLessons = async (id: number) => {                       
    const res = await axios.get(`${api}/lessons/${id}`)
    return res.data
}
export const getCourserbyUserId = async (userid: number) => {
    const res = await axios.get(`${api}/carts/${userid}`)
    return res.data
}
export const addCarts = async (users_id : number, course_id: number) => {
    const res = await axios.post(`${api}/carts/addCourse`, {
        users_id,
        course_id,
    })
    return res.data
}
export const deletecarts = async (coursesid: number, userid: 1) => {
    const res = await axios.delete(`${api}/carts/${coursesid}/${userid}`)
    return res.data
}
