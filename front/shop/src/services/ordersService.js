import apiClient from "./apiClient";

const API_URL_ROUTE = '/api/v1/orders';

export async function createOrder(params) {
    try {
        const response = await apiClient.post(API_URL_ROUTE, params);
        return response;
    }
    catch(error) {
        throw new Error(error.message);
    }
}

export async function getMyOrders() {
    try {
        const response = await apiClient.get(`${API_URL_ROUTE}/my`);
        return response.data.data;
    }
    catch(error) {
        throw new Error(error.response?.data || error.message);
    }
}