UPDATE Clicks
SET LinkIdentifier = @LinkIdentifier,
    Clicked = @Clicked
WHERE Identifier = @Identifier;