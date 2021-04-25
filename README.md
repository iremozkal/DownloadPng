# DOWNLOAD PNG

Basic console app to download images from file.  
All files (flag-image-links.txt, country-iso-codes.txt) were created with data pulled from the Booking.com.


## Pull data from Booking.com 

You can get data of iso codes, phone codes, and the image links of flags for each country (248) from booking.com by the browser console with javascript.  

You can easily access country-related data under the personal details/phone number menu link + edit button. There are 248 country options on the dropdown.   
```select class="bui-form__control" name="dial_code"``` area contains all the countries. By choosing this line of the code, you can read all the data from console with javascript like below:   


```bash
$0                               # gives current element (in this case <select>)  
var option = $$('option', $0)    # gives the options under the select  
var countries = [];
for (i = 1; i < option.length; i++) {
	countries[i] = option[i].innerText;
	console.log(countries[i]);
}
```

## Files
> Inputs  
[flag-image-links.txt](https://github.com/iremozkal/DownloadPng/blob/main/DownloadPng/bin/Debug/Files/flag-image-links.txt)  
[country-iso-codes.txt](https://github.com/iremozkal/DownloadPng/blob/main/DownloadPng/bin/Debug/Files/country-iso-codes.txt)  

> Outputs  
[Flags/](https://github.com/iremozkal/DownloadPng/tree/main/DownloadPng/bin/Debug/Flags)   



## Output
```bash
. Flag 1   'xa.png' downloaded.  
. Flag 2   'af.png' downloaded.  
. . .   
. Flag 246 'ye.png' downloaded.  
. Flag 247 'zm.png' downloaded.  
. Flag 248 'zw.png' downloaded.  

 . 248 flag images has been successfully downloaded.
```
