package services

import (
	"errors"
	"golang.org/x/crypto/bcrypt"
	"sign-service/internal/models"
	"sign-service/internal/repositories/interfaces"
)

func AuthenticateUser(userRepository interfaces.UserRepositoryInterface, email, password string) (string, error) {
	user, err := userRepository.FindUserByEmail(email)
	if err != nil {
		return "", errors.New("incorrect data")
	}
	if user == nil {
		return "", errors.New("incorrect data")
	}

	err = bcrypt.CompareHashAndPassword([]byte(user.PasswordHash), []byte(password))
	if err != nil {
		return "", errors.New("incorrect data")
	}

	token, err := GenerateToken(user)
	if err != nil {
		return "", err
	}

	return token, nil
}

func RegisterUser(userRepository interfaces.UserRepositoryInterface, request *models.RegisterRequest) (string, error) {
	hashedPassword, err := bcrypt.GenerateFromPassword([]byte(request.Password), bcrypt.DefaultCost)
	if err != nil {
		return "", err
	}
	request.Password = string(hashedPassword)

	user, err := userRepository.CreateUser(request)
	if err != nil {
		return "", err
	}

	token, err := GenerateToken(user)
	if err != nil {
		return "", err
	}

	return token, nil
}
