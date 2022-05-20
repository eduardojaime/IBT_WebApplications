--- USERS TABLE
--- Authentication: making sure users are who they say they are
--- Basic: username/password
--- Third Party Oauth: linked to google, twitter, microsoft, facebook, etc...
SELECT * FROM dbo.AspNetUsers

--- ROLES TABLE
--- Authorization: What actions can they perform once authenticated?
--- Basic: LoggedIn vs LoggedOut (Anonymous)
--- E.g.: Admin, Client, SecurityAdmin, etc...
--- Roles are 'labels' to group users and provide access accordingly in our application (code)
SELECT * FROM dbo.AspNetRoles -- define roles 
SELECT * FROM dbo.AspNetUserRoles -- assign roles to users by id

INSERT INTO dbo.AspNetRoles 
VALUES 
(1, 'Admin', 'ADMIN', null), 
(2, 'Client', 'CLIENT', null)

INSERT INTO dbo.AspNetUserRoles VALUES ('4c23d45a-962b-4ccd-ac9c-0c7172caa70f', 1);