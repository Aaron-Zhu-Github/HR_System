-- Add isSecondary to Address table 
ALTER TABLE Address
ADD isSecondary BIT NOT NULL DEFAULT 0;

-- Add work email to Person table 
ALTER TABLE Person
ADD WorkEmail VARCHAR(255);

-- Add preferred name to Person table 
ALTER TABLE Person
ADD PreferredName VARCHAR(50);
