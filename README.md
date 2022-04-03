# Discord-Token-Grabber
Sends embed to discord webhook containing Discord token, PC Name, Username, and  Internal ip


# How to use?
Clone this repo and inside PrintAllInfo.cs you should see a url string, replace the url with your own discord webhook (not the double quotes)
you can publish as onefile and when ran, it will send an embed containing users details.


# Bypassing?
Ran program in virustotal, bypassed every single antivirus "No security vendors and no sandboxes flagged this file as malicious
" Windows defender warning will popup (if you're on windows) while trying to run, but thats about it.

# Flexibility?
May fail, only tested on windows. has dependencies, but if you publish as onefile it will do fine, just zip it up if its too big.


# About
Spent 3/4 of time fixing a Bad Webrequest 400 issue, couldn't filter all possible tokens, feel really stupid now because i just used a foreach loop and it worked 💀
Not very well tested, only ran on two pcs. Hopefully it works 🙂




skidded some code from another outdated token grabber that throws errors.
