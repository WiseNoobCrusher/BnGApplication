SELECT U.UserName, R.Name
FROM AspNetUsers U LEFT JOIN AspNetUserRoles S
	ON U.Id = S.userId
LEFT JOIN AspNetRoles R
	ON R.Id = S.RoleId