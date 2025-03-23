package database

import (
	"database/sql"
	"fmt"
	_ "github.com/lib/pq"
	"golang.org/x/crypto/bcrypt"
	"log"
)

var DB *sql.DB

func Connect(connStr string) {
	var err error
	DB, err = sql.Open("postgres", connStr)
	if err != nil {
		log.Fatal("Connection DB error:", err)
	}

	err = DB.Ping()
	if err != nil {
		log.Fatal("Ping error", err)
	}

	createAdmin()

	fmt.Println("Successfully connected to DB")
}

func createAdmin() {
	var count int
	err := DB.QueryRow("SELECT COUNT(*) FROM users WHERE role = $1", "Admin").Scan(&count)
	if err != nil {
		log.Fatal(err)
	}

	if count == 0 {
		password := []byte("aa")
		hashedPassword, err := bcrypt.GenerateFromPassword(password, bcrypt.DefaultCost)
		if err != nil {
			log.Fatal(err)
		}

		_, err = DB.Exec(`INSERT INTO users (username, email, password_hash, role)
		                   VALUES ('aa', 'aa', $1, 'Admin')`, hashedPassword)
		if err != nil {
			log.Fatal(err)
		}
		fmt.Println("Admin user created.")
	} else {
		fmt.Println("Admin user already exists.")
	}
}
