# 1. makecert

openssl req -x509 -newkey rsa:2048 -keyout ${HOME}/.aspnet/https/localhost.key -out ${HOME}/.aspnet/https/localhost.crt -days 365 -subj "/CN=chat.local/O=chat.local/C=US" -config ./ssl.cnf -passout pass:MyPass
openssl pkcs12 -export -out ${HOME}/.aspnet/https/localhost.pfx -inkey ${HOME}/.aspnet/https/localhost.key -in ${HOME}/.aspnet/https/localhost.crt -name "Localhost selfsigned certificate" -password pass:MyPass -passin pass:MyPass
openssl rsa -in ${HOME}/.aspnet/https/localhost.key -out ${HOME}/.aspnet/https/localhost.key -passin pass:MyPass

# 2. [trustcert](https://gist.github.com/epcim/03f66dfa85ad56604c7b8e6df79614e0)

certutil -addstore -f "ROOT" ${HOME}/.aspnet/https/localhost.crt

# 3. hostadd

Add-Content -Path $env:windir\System32\drivers\etc\hosts -Value "`n172.21.112.1`tchat.local" -Force