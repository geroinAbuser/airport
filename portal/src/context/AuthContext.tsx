import { createContext, useState, useContext, ReactNode, useEffect } from "react";
import { jwtDecode } from "jwt-decode";

interface User {
    username: string;
    role: string;
}

interface AuthContextType {
    user: User | null;
    isLoading: boolean;
    login: (token: string) => void;
    logout: () => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
    const [user, setUser] = useState<User | null>(null);
    const [isLoading, setIsLoading] = useState(true); // Добавляем состояние загрузки

    useEffect(() => {
        const token = localStorage.getItem("token");
        if (token) {
            try {
                const decoded: { username: string; role: string } = jwtDecode(token);
                setUser({ username: decoded.username, role: decoded.role });
            } catch (error) {
                console.error("Invalid token", error);
                localStorage.removeItem("token");
            }
        }
        setIsLoading(false); // Завершаем загрузку после проверки токена
    }, []);

    const login = (token: string) => {
        localStorage.setItem("token", token);
        try {
            const decoded: { username: string; role: string } = jwtDecode(token);
            setUser({ username: decoded.username, role: decoded.role });
        } catch (error) {
            console.error("Invalid token", error);
            setUser(null);
        }
    };

    const logout = () => {
        localStorage.removeItem("token");
        setUser(null);
    };

    return (
        <AuthContext.Provider value={{ user, isLoading, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    const context = useContext(AuthContext);
    if (!context) throw new Error("useAuth must be used within an AuthProvider");
    return context;
};
