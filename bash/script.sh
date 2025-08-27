#!/bin/bash

gradient_text() {
    local text="$1"
    local length=${#text}
    local colors=(48 49 51 39 27) 
    #196 202 208 214 220 226 190 154 118 82 46 47 48 49 51 39 27 21 93 99 105) 
    local color_count=${#colors[@]}
    for (( i=0; i<length; i++ )); do
        local char="${text:i:1}"
        local color_index=$(( i * (color_count-1) / (length-1) ))
        local color_code=${colors[$color_index]}
        printf "\e[38;5;%sm%s" "$color_code" "$char"
    done
    printf "\e[0m\n"
}

gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⡟⡿⢯⡻⡝⢯⡝⡾⣽⣻⣟⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢻⠳⣏⠧⠹⡘⢣⠑⠎⠱⣈⠳⢡⠳⢭⣛⠷⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣝⣎⢣⠡⠌⣢⠧⠒⠃⠁⠈⠉⠉⠑⠓⠚⠦⣍⡞⡽⣞⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣝⠮⡜⣢⠕⠊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠐⠄⡙⠲⣝⡺⡽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ Linux"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⡹⢎⣳⠞⡡⠊⠀⠀⠀⣀⣤⣤⣶⣶⣤⣤⣀⡈⠂⠄⠙⠱⡌⠳⣹⢎⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ $(lsb_release -si) $(lsb_release -sr)"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣽⣟⣳⡝⡼⢁⠎⠀⡀⢁⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⡄⠰⣄⠈⠓⢌⠛⢽⣣⡟⢿⠿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿ $(uname -r)"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⡿⣽⠳⡼⢁⡞⠀⡜⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡆⢸⢵⠀⠀⠁⠂⠤⣉⠉⠓⠒⠚⠦⠥⡈⠉⣙⢛⡿⣿"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⡾⣽⣏⢳⢃⣞⠃⡼⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠁⢀⣀⠤⠐⢋⡰⣌⣾⣿⣿ dotnet $(dotnet --version)"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣮⢳⣿⠶⠁⠖⠃⠀⠁⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠿⠟⠛⠛⠀⠀⠀⠀⢀⡤⠤⠐⠒⣉⠡⣄⠶⣭⣿⣽⣿⣿⣿⣿ vscode $(code --version | head -1)"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⡿⠿⢉⡢⠝⠁⠀⠃⠀⠀⠀⠀⠀⠿⠃⠿⠿⠿⠛⠋⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⣀⢤⣰⣲⣽⣾⡟⣾⣿⣿⣿⣿⣿⣿⣿⣿"
gradient_text "⣿⣿⣟⡿⡚⠏⠁⠀⠐⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠂⣠⠀⣯⣗⣮⢿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ $USER"
gradient_text "⣿⢯⡝⠠⠁⠀⠀⠠⠤⠀⠀⠀⠀⡀⠢⣄⣀⡀⠐⠤⡀⠀⠀⠀⢤⣄⣀⠤⣄⣤⢤⣖⡾⠋⢁⡼⠁⣸⡿⣞⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ $HOSTNAME, Inc."
gradient_text "⣿⣷⣾⣵⣦⣶⣖⣳⣶⣝⣶⣯⣷⣽⣷⣾⣶⣽⣯⣶⠄⠈⠒⣤⣀⠉⠙⠛⠛⠋⠋⢁⣠⠔⠁⠀⢰⣿⣽⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⡄⡀⡉⠛⠓⠶⠶⠒⠛⠋⠀⠀⢀⣼⣻⢷⣾⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣧⡵⣌⣒⢂⠀⣀⣀⣠⣤⣶⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
gradient_text "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣾⣷⣯⣿⣧⣿⣷⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"

exec /bin/bash
