IF NOT EXISTS (SELECT 1 FROM Gender WHERE GenderName = 'Male')
    INSERT INTO Gender (GenderName) VALUES ('Male');

IF NOT EXISTS (SELECT 1 FROM Gender WHERE GenderName = 'Female')
    INSERT INTO Gender (GenderName) VALUES ('Female');

IF NOT EXISTS (SELECT 1 FROM Gender WHERE GenderName = 'Divers')
    INSERT INTO Gender (GenderName) VALUES ('Divers');
