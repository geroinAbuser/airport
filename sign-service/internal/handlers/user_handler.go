package handlers

import (
	"encoding/json"
	"net/http"
	"sign-service/internal/models"
	"sign-service/internal/repositories"
	"sign-service/internal/services"
)

// LoginUser godoc
// @Summary      User authentication
// @Description  Authenticates the user and returns a JWT token
// @Tags         users
// @Accept       json
// @Produce      json
// @Param        user  body  models.LoginRequest  true  "User authentication data"
// @Success      200  {string}  string  "JWT Token"
// @Failure      400  {string}  string  "Invalid JSON"
// @Failure      401  {string}  string  "Invalid login credentials"
// @Router       /login [post]
func LoginUser(w http.ResponseWriter, r *http.Request) {
	var request models.LoginRequest

	if err := json.NewDecoder(r.Body).Decode(&request); err != nil {
		http.Error(w, "Wrong json", http.StatusBadRequest)
		return
	}

	userRepository := &repositories.UserRepository{}
	token, err := services.AuthenticateUser(userRepository, request.Email, request.Password)
	if err != nil {
		http.Error(w, "Incorrect auth data", http.StatusUnauthorized)
		return
	}

	w.WriteHeader(http.StatusOK)
	json.NewEncoder(w).Encode(map[string]string{
		"token": token,
	})
}

// CreateUser godoc
// @Summary      Create a new user
// @Description  Registers a new user in the system
// @Tags         users
// @Accept       json
// @Produce      json
// @Param        user  body  models.RegisterRequest  true  "User registration data"
// @Success      201  {object}  models.RegisterRequest
// @Failure      400  {string}  string  "Invalid JSON"
// @Failure      500  {string}  string  "Registration error"
// @Router       /register [post]
func CreateUser(w http.ResponseWriter, r *http.Request) {
	var request models.RegisterRequest

	if err := json.NewDecoder(r.Body).Decode(&request); err != nil {
		http.Error(w, "Wrong json", http.StatusBadRequest)
		return
	}

	userRepository := &repositories.UserRepository{}
	token, err := services.RegisterUser(userRepository, &request)
	if err != nil {
		http.Error(w, "Registration error", http.StatusInternalServerError)
		return
	}

	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(map[string]string{
		"token": token,
	})
}
