package servers

import (
	"fmt"
	"github.com/gorilla/mux"
	httpSwagger "github.com/swaggo/http-swagger"
	"log"
	"net/http"
	"sign-service/internal/handlers"
)

func StartHTTPServer(httpPort string, frontendURL string) {
	r := mux.NewRouter()

	r.Use(corsMiddleware(frontendURL))

	r.HandleFunc("/login", handlers.LoginUser).Methods("OPTIONS", "POST")
	r.HandleFunc("/register", handlers.CreateUser).Methods("OPTIONS", "POST")

	r.PathPrefix("/swagger/").Handler(httpSwagger.WrapHandler)

	fmt.Printf("HTTP server port %s\n", httpPort)
	log.Fatal(http.ListenAndServe(fmt.Sprintf(":%s", httpPort), r))
}

func corsMiddleware(frontendURL string) func(http.Handler) http.Handler {
	return func(next http.Handler) http.Handler {
		return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
			w.Header().Set("Access-Control-Allow-Origin", frontendURL)
			w.Header().Set("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS")
			w.Header().Set("Access-Control-Allow-Headers", "Content-Type, Authorization")
			w.Header().Set("Access-Control-Allow-Credentials", "true")

			if r.Method == "OPTIONS" {
				w.WriteHeader(http.StatusOK)
				return
			}

			next.ServeHTTP(w, r)
		})
	}
}
