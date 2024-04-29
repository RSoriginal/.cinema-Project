# Cinema Ticket Booking Project

This is a web application developed using ASP .NET Core MVC for booking cinema tickets. It allows users to browse movies, view showtimes, and book tickets online.

## Features

- **User Authentication:** Secure user authentication system allowing users to sign up, log in, and log out.
- **Movie Listings:** Browse through a list of movies currently playing in the cinema.
- **Showtimes:** View showtimes for each movie.
- **Ticket Booking:** Book tickets for desired showtimes.
- **Seat Selection:** Select seats for booking tickets.
- **Admin Panel:** An admin panel to manage movies, showtimes, and user bookings.

## Technologies Used

- **ASP .NET Core MVC:** The framework used for building the web application.
- **Entity Framework Core:** For interacting with the database.
- **HTML/CSS/JavaScript:** Frontend development technologies.
- **MS SQL Server:** As the backend database.
- **Identity Framework:** For user authentication and authorization.

## Setup Instructions

1. **Clone the Repository:**
    ```bash
    git clone https://github.com/RSoriginal/.cinema-Project
    ```

2. **Restore Dependencies:**
    ```bash
    dotnet restore
    ```

3. **Update Database:**
    ```bash
    dotnet ef database update
    ```

4. **Run the Application:**
    ```bash
    dotnet run
    ```

5. **Access the Application:**
    Open your web browser and navigate to server url.

## License

This project is licensed under the [MIT License](LICENSE).
