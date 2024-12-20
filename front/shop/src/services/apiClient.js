import axios from "axios";

const apiClient = axios.create({
    baseURL: 'https://zd3rdtwk-5282.euw.devtunnels.ms', //заменить на нужный url http://localhost:5282
    headers: {
    'Content-Type': 'application/json',
  },
});

apiClient.interceptors.request.use((config) => {
    const token = localStorage.getItem('authToken');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
});

export default apiClient;