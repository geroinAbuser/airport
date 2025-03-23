package servers

import (
	"fmt"
	"google.golang.org/grpc"
	"log"
	"net"
	"sign-service/internal/proto/authpb"
	"sign-service/internal/services"
)

func StartGRPCServer(grpcPort string) {
	lis, err := net.Listen("tcp", fmt.Sprintf(":%s", grpcPort))
	if err != nil {
		log.Fatalf("Running grpc server error: %v", err)
	}

	grpcServer := grpc.NewServer()
	authpb.RegisterAuthServiceServer(grpcServer, &services.AuthService{})

	fmt.Printf("grpc server port: %s\n", grpcPort)
	if err := grpcServer.Serve(lis); err != nil {
		log.Fatalf("Running grpc server error: %v", err)
	}
}
