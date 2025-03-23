package services

import (
	"context"
	"errors"
	"sign-service/internal/proto/authpb"
)

type AuthService struct {
	authpb.UnimplementedAuthServiceServer
}

func (s *AuthService) ValidateToken(ctx context.Context, req *authpb.ValidateTokenRequest) (*authpb.ValidateTokenResponse, error) {
	token := req.GetToken()

	claims, err := ParseToken(token)
	if err != nil {
		return &authpb.ValidateTokenResponse{
			IsValid: false,
		}, errors.New("invalid token")
	}

	return &authpb.ValidateTokenResponse{
		IsValid:  true,
		UserId:   claims.UserID.String(),
		Username: claims.Username,
		Email:    claims.Email,
		Role:     claims.Role,
	}, nil
}
