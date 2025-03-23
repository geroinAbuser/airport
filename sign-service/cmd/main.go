package main

import (
	_ "sign-service/cmd/docs"
	"sign-service/config"
	"sign-service/internal/database"
	"sign-service/internal/servers"
	"sign-service/internal/services"
)

// @title Sign Service API
// @version 1.0
// @description This is a sample API for user sign-ups
// @host localhost:8080
// @BasePath /
func main() {
	config.Init()

	services.InitJWT(config.AppConfig.JWTSecretKey)

	database.Connect(config.AppConfig.DBConnectionString)

	go servers.StartGRPCServer(config.AppConfig.GRPCPort)

	servers.StartHTTPServer(config.AppConfig.HTTPPort, config.AppConfig.FrontendURL)
}
