#!/bin/sh

# VAGRANT user settings

# Add basic syntax highlighting for C# in nano

echo Adding C# code highlighting for Nano

cat > ~/.nanorc << EOL
syntax "C# source" "\.cs$"
color green "\<(bool|byte|sbyte|char|decimal|double|float|int|uint|long|ulong|new|object|short|ushort|string|base|this|void)\>"
color red "\<(as|break|case|catch|checked|continue|default|do|else|finally|fixed|for|foreach|goto|if|is|lock|return|switch|throw|try|unchecked|while)\>"
color cyan "\<(abstract|class|const|delegate|enum|event|explicit|extern|implicit|in|internal|interface|namespace|operator|out|override|params|private|protected|public|readonly|ref|sealed|sizeof|static|struct|typeof|using|virtual|volatile)\>"
color red ""[^\"]*""
color yellow "\<(true|false|null)\>"
color blue "//.*"
color blue start="/\*" end="\*/"
color brightblue start="/\*\*" end="\*/"
color brightgreen,green " +$"
EOL