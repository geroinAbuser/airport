package interfaces

import "sign-service/internal/models"

type UserRepositoryInterface interface {
	FindUserByEmail(email string) (*models.User, error)
	CreateUser(request *models.RegisterRequest) (*models.User, error)
}
