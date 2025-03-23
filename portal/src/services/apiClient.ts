const API_BASE_URL = process.env.REACT_APP_API_BASE_URL;
const AUTH_API_BASE_URL = process.env.REACT_APP_AUTH_API_BASE_URL;

const getToken = () => localStorage.getItem("token");

export const request = async (endpoint: string, method = "GET", body?: any, baseUrl = API_BASE_URL) => {
    try {
        const response = await fetch(`${baseUrl}/${endpoint}`, {
            method,
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${getToken()}`,
            },
            body: body ? JSON.stringify(body) : undefined,
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`API Error: ${response.status} ${errorText}`);
        }

        if (response.status === 201) return response.text();
        if (response.status !== 204) return response.json();

        return null;
    } catch (error) {
        console.error("API request failed:", error);
        throw error;
    }
};

export const loginUser = async (email: string, password: string) => {
    return request("login", "POST", { email, password }, AUTH_API_BASE_URL);
};

export const registerUser = async (email: string, username: string, password: string) => {
    return request("register", "POST", { email, username, password }, AUTH_API_BASE_URL);
};
