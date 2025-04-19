CREATE TABLE CATEGORY (
	ID_CATEGORY INT PRIMARY KEY IDENTITY(1, 1),
	NAME VARCHAR(30) NOT NULL
)

CREATE TABLE CONTENT (
	ID_CONTENT INT PRIMARY KEY IDENTITY(1, 1),
	DESCRIPTION VARCHAR(50) NOT NULL
)

CREATE TABLE FILM (
	ID_FILM INT PRIMARY KEY IDENTITY(1, 1),
	NAME VARCHAR(50) NOT NULL,
	DURATION SMALLINT NOT NULL,
	CLASSIFICATION VARCHAR(5) NOT NULL,
	SYNOPSIS VARCHAR(MAX) NOT NULL,
	THUMBNAIL VARCHAR(200) NOT NULL,
	MEDIA VARCHAR(200) NOT NULL,
	PREVIEW VARCHAR(200) NOT NULL,
	YEAR SMALLINT NOT NULL
)

CREATE TABLE FILM_CATEGORY (
	ID_FILM_CATEGORY INT PRIMARY KEY IDENTITY(1, 1),
	ID_FILM INT NOT NULL,
	ID_CATEGORY INT NOT NULL,
	FOREIGN KEY (ID_FILM)
	REFERENCES FILM(ID_FILM),
	FOREIGN KEY (ID_CATEGORY)
	REFERENCES CATEGORY(ID_CATEGORY),
)

CREATE TABLE FILM_CONTENT (
	ID_FILM_CONTENT INT PRIMARY KEY IDENTITY(1, 1),
	ID_FILM INT NOT NULL,
	ID_CONTENT INT NOT NULL,
	FOREIGN KEY (ID_FILM)
	REFERENCES FILM(ID_FILM),
	FOREIGN KEY (ID_CONTENT)
	REFERENCES CONTENT(ID_CONTENT),
)

CREATE TABLE CAST (
	ID_CAST INT PRIMARY KEY IDENTITY(1, 1),
	NAME VARCHAR(100) NOT NULL,
	CHARACTER VARCHAR(100) NOT NULL,
	ID_FILM INT NULL,
	ID_SERIES INT NULL,
	SEASON INT NULL,
	FOREIGN KEY (ID_FILM)
	REFERENCES FILM(ID_FILM),
	FOREIGN KEY (ID_SERIES)
	REFERENCES SERIES(ID_SERIES)
)

CREATE TABLE SERIES (
	ID_SERIES INT PRIMARY KEY IDENTITY(1, 1),
	NAME VARCHAR(50) NOT NULL,
	CLASSIFICATION VARCHAR(5) NOT NULL,
	SYNOPSIS VARCHAR(150) NOT NULL,
	THUMBNAIL VARCHAR(200) NOT NULL,
	PREVIEW VARCHAR(200) NOT NULL,
	ID_CATEGORY INT NOT NULL,
	FOREIGN KEY (ID_CATEGORY)
	REFERENCES CATEGORY(ID_CATEGORY)
)

CREATE TABLE SERIES_EPISODE (
	ID_SERIES_EDIPOSE INT PRIMARY KEY IDENTITY(1, 1),
	NAME VARCHAR(50) NOT NULL,
	SEASON INT NOT NULL,
	EPISODE INT NOT NULL,
	DURATION INT NOT NULL,
	SYNOPSIS VARCHAR(150) NOT NULL,
	THUMBNAIL VARCHAR(200) NOT NULL,
	MEDIA VARCHAR(200) NOT NULL,
	YEAR INT NOT NULL,
	ID_SERIES INT NOT NULL,
	ID_CONTENT INT NOT NULL,
	FOREIGN KEY (ID_SERIES)
	REFERENCES SERIES(ID_SERIES),
	FOREIGN KEY (ID_CONTENT)
	REFERENCES CONTENT(ID_CONTENT)
)

CREATE TABLE [USER] (
	ID_USER INT PRIMARY KEY IDENTITY(1, 1),
	EMAIL VARCHAR(100) NOT NULL,
	PASSWORD VARCHAR(100) NOT NULL
)

CREATE TABLE PROFILE (
	ID_PROFILE INT PRIMARY KEY IDENTITY(1, 1),
	NAME VARCHAR(30) NOT NULL,
	AVATAR VARCHAR(200) NULL,
	ID_USER INT NOT NULL
	FOREIGN KEY (ID_USER)
	REFERENCES [USER](ID_USER)
)

CREATE TABLE MY_LIST (
	ID_MY_LIST INT PRIMARY KEY IDENTITY(1, 1),
	ID_FILM INT NULL,
	ID_SERIES INT NULL,
	ID_PROFILE INT NOT NULL
	FOREIGN KEY (ID_PROFILE)
	REFERENCES PROFILE(ID_PROFILE)
)

CREATE TABLE KEEP_WHATCHING (
	ID_KEEP_WHATCHING INT PRIMARY KEY IDENTITY(1, 1),
	ID_FILM INT NULL,
	ID_SERIES_EPISODE INT NULL,
	DURATION INT NOT NULL,
	ID_PROFILE INT NOT NULL
	FOREIGN KEY (ID_PROFILE)
	REFERENCES PROFILE(ID_PROFILE)
)