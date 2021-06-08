UPDATE Links
SET Url = @Url,
    Slug = @Slug,
    Updated = @Updated
WHERE Identifier = @Identifier;