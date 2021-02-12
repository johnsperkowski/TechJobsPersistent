--Part 1
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = "jobs";
--Part 2
SELECT Name
FROM techjobs.employers
WHERE location = "St. Louis";
--Part 3
SELECT DISTINCT Name, Description
FROM skills INNER JOIN jobskills
ON skills.Id = jobskills.skillId
WHERE jobskills.JobId is not null;

