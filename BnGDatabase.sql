USE BnGDatabase
GO

CREATE TABLE Users (
	userID			INT	IDENTITY(1,1),
	userFName		VARCHAR(50),
	userMName		VARCHAR(50),
	userLName		VARCHAR(100),
	userEmail		VARCHAR(255),
	userPhone		INT,

	CONSTRAINT PK_Users_UserID PRIMARY KEY (userID)
);

CREATE TABLE Child (
	childID			INT	IDENTITY(1,1),
	childFName		VARCHAR(50),
	childMName		VARCHAR(50),
	childLName		VARCHAR(100),
	childDOB		DATETIME,
	userID			INT,

	CONSTRAINT PK_Child_childID PRIMARY KEY (childID),
	CONSTRAINT FK_Users_userID FOREIGN KEY(userID) REFERENCES Users(userID) 
);

CREATE TABLE Activity (
	actID				INT IDENTITY(1,1),
	actName				VARCHAR(100),
	actDescription		VARCHAR(500),
	actCode				VARCHAR(10),
	actRequirement		VARCHAR(250),
	actAvailablePlace	VARCHAR(30),
	leaderID			INT,
	acttypeID			INT,

	CONSTRAINT PK_Activity_actID PRIMARY KEY(actID)
);

CREATE TABLE childEnrolled (
	ceID			INT IDENTITY(1,1),
	actID			INT,
	childID			INT,

	CONSTRAINT PK_childEnrolled_ceID PRIMARY KEY(ceID),
	CONSTRAINT FK_Activity_actID FOREIGN KEY(actID) REFERENCES Activity(actID),
	CONSTRAINT FK_Child_childID FOREIGN KEY(childID) REFERENCES Child(childID)
);