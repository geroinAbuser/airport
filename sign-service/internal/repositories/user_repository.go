package repositories

import (
	"sign-service/internal/database"
	"sign-service/internal/models"
)

type UserRepository struct {
}

func (repo *UserRepository) FindUserByEmail(email string) (*models.User, error) {
	var user models.User
	err := database.DB.QueryRow("SELECT id, username, email, password_hash, role FROM users WHERE email = $1", email).Scan(&user.ID, &user.Username, &user.Email, &user.PasswordHash, &user.Role)
	if err != nil {
		if err.Error() == "no rows in result set" {
			return nil, nil
		}
		return nil, err
	}
	return &user, nil
}

func (repo *UserRepository) CreateUser(request *models.RegisterRequest) (*models.User, error) {
	user := models.User{}
	user.Role = "User"
	query := "INSERT INTO users (username, email, password_hash, role) VALUES ($1, $2, $3, $4) RETURNING id, username, email, role"
	err := database.DB.QueryRow(query, request.Username, request.Email, request.Password, user.Role).Scan(&user.ID, &user.Username, &user.Email, &user.Role)
	if err != nil {
		return nil, err
	}

	return &user, nil
}
