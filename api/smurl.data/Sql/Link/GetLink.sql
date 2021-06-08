SELECT
    Identifier,
    Url,
    Slug,
    Created,
    Updated
FROM Links
WHERE Slug = @Slug;