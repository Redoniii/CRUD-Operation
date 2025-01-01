CREATE DATABASE REDONI
USE REDONI;


CREATE TABLE Names
(
	ID INT NOT NULL IDENTITY(1,1),
	FirstName VARCHAR(100),
	SecondName VARCHAR(100)
)

SELECT * FROM NAMES ORDER BY ID ASC

DELETE FROM NAMES WHERE FirstName = 'Ilmi' AND SecondName = 'Berisha' AND ID = 46;

UPDATE Names SET FirstName = 'Redonii' , SecondName = 'Berisha' WHERE ID = 11;

INSERT INTO NAMES (FirstName, SecondName) VALUES ('Redon', 'Berisha')


