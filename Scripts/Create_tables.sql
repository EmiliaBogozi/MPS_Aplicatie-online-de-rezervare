
DROP TABLE Contact2;
DROP TABLE Favorite_classes;
DROP TABLE Reservation;
DROP TABLE Resources;
DROP TABLE Member;

CREATE TABLE Member(
    member_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(25) NOT NULL,
    last_name NVARCHAR(25) NOT NULL,
    member_group NVARCHAR(10) NOT NULL,
    member_username NVARCHAR(50) NOT NULL UNIQUE,
    member_password NVARCHAR(20) NOT NULL,
    -- admin(poate rezerva sala)/user(poate vedea rezervari)
    member_role NVARCHAR(20) NOT NULL
);

CREATE TABLE Resources(
    resource_id INT IDENTITY(1,1) PRIMARY KEY,
    resource_name NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Reservation(
    reservation_id INT IDENTITY(1,1) PRIMARY KEY,
    resource_id INT NOT NULL FOREIGN KEY REFERENCES [Resources](resource_id),
    member_id INT NOT NULL FOREIGN KEY REFERENCES [Member](member_id),
    group_reservation NVARCHAR(10) NOT NULL,
    reason_reservation NVARCHAR(100) NOT NULL,
    -- Data cand incepe rezervarea
    reservation_year INT NOT NULL,
    reservation_month INT NOT NULL,
    reservation_day INT NOT NULL,
    reservation_hour INT NOT NULL,
    reservation_minute INT NOT NULL,
    --durata
    reservation_time INT NOT NULL
);

CREATE TABLE Favorite_classes(
    member_id INT NOT NULL FOREIGN KEY REFERENCES [Member](member_id),
    resource_id INT NOT NULL FOREIGN KEY REFERENCES [Resources](resource_id)
);

CREATE TABLE Contact2
(
    first_name NVARCHAR(20) NOT NULL,
    last_name NVARCHAR(20) NOT NULL,
    email NVARCHAR(50) NOT NULL,
    phone_number NVARCHAR(11),
    message_text NVARCHAR(1000) NOT NULL
);





