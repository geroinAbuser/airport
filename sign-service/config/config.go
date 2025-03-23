package config

import (
	"log"
	"os"
)

type Config struct {
	DBConnectionString string
	GRPCPort           string
	HTTPPort           string
	JWTSecretKey       string
	FrontendURL        string
}

var AppConfig Config

func Init() {
	/*err := godotenv.Load()
	if err != nil {
		log.Fatalf("Loading .env.example file error: %v", err)
	}*/

	AppConfig = Config{
		DBConnectionString: getEnv("DB_CONNECTION_STRING"),
		GRPCPort:           getEnv("GRPC_PORT"),
		HTTPPort:           getEnv("HTTP_PORT"),
		JWTSecretKey:       getEnv("JWT_SECRET_KEY"),
		FrontendURL:        getEnv("FRONTEND_URL"),
	}

	log.Println("Successfully loaded .env.example file")
}

func getEnv(key string, defaultValue ...string) string {
	if value, exists := os.LookupEnv(key); exists {
		return value
	}
	if len(defaultValue) > 0 {
		return defaultValue[0]
	}
	log.Fatalf("Var %s not found!", key)
	return ""
}
