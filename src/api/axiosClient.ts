// src/api/axiosClient.ts
import axios from 'axios';

const instance = axios.create({
  baseURL: import.meta.env.VITE_API_BACKEND_URL, // sửa theo backend của bạn
  timeout: 10000,
});

// Request interceptor -> thêm token vào header
instance.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('accessToken');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);


export default instance;
