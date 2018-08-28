public void Parse()
{
    StringReader reader = new StringReader(scriptTextToProcess);
    StringBuilder scope = new StringBuilder();
    string line = reader.ReadLine();
    while (line != null)
    {
        switch (line[0])
        {
            case '$':
                // Process the entire "line" as a variable, 
                // i.e. add it to a collection of KeyValuePair.
                AddToVariables(line);
                break;
            case '!':
                // Depending of what comes after the '!' character, 
                // process the entire "scope" and/or the command in "line".
                if (line == "!execute")
                    ExecuteScope(scope);
                else if (line.StartsWith("!custom_command"))
                    RunCustomCommand(line, scope);
                else if (line == "!single_line_directive")
                    ProcessDirective(line);
 
                scope = new StringBuilder();
                break;
 
            default:
                // No processing directive, i.e. add the "line" 
                // to the current scope.
                scope.Append(line);
                break;
        }
 
        line = reader.ReadLine();
    }
}
 
