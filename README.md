# BMW_Data_Reader
Read the BMW connected drive data from the website

Based on https://www.active-tourer-forum.de/index.php/Thread/1231-Auslesen-der-BMW-Daten-mit-FHEM-225xe/?pageNo=4

Actually the data only will be read from the BMW-Site. Parsing and statistics will be done later. (maybe a different Tool)

# Usage

## After the first start
The program ask for a storage path. This path is stored inside of the user profile inside of windows.
Inside of this path the credentials and the request results from the BMW site will be stored.

Enter the required three fields on the top: Login, Password and VIN
When you don't like to enter them every time you could save them with a password. Your data is not stored on disk in plain text.

## Normal operation
If you have stored the credentials the program ask for the password.
the just push Read Data and the program log in on the BMW site. All received data is stored in the shown path.

```
        //https://www.bmw-connecteddrive.de/api/vehicle/service/v1/ {0}=VIN                           srv*.txt
        //https://www.bmw-connecteddrive.de/api/vehicle/servicepartner/v1/ {0}=VIN                    srP*.txt
        //https://www.bmw-connecteddrive.de/api/vehicle/navigation/v1/ {0}=VIN                        not read yet
        //https://www.bmw-connecteddrive.de/api/vehicle/efficiency/v1/ {0}=VIN                        eff*.txt
        //https://www.bmw-connecteddrive.de/api/vehicle/remoteservices/chargingprofile/v1/ {0}=VIN    rem*.txt
        //https://www.bmw-connecteddrive.de/api/me/service/mapupdate/download/v1/ {0}=VIN             not read yet
        //https://www.bmw-connecteddrive.de/api/vehicle/dynamic/v1/ {0}=VIN ?offset=-120              dyn*.txt
```

