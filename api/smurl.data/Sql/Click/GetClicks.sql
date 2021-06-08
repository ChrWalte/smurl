SELECT
    Identifier,
    LinkIdentifier,
    Clicked
FROM Clicks
WHERE LinkIdentifier = @LinkIdentifier;