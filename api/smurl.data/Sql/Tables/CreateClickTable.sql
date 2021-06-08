CREATE TABLE Clicks(
    Identifier UUID NOT NULL PRIMARY KEY,
    LinkIdentifier UUID NOT NULL,
    Clicked TEXT NOT NULL
);