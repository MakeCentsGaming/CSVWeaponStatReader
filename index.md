---
layout: main
---

# CSVWeaponStatReader

[![Donate](https://img.shields.io/badge/Donate-PayPal-yellowgreen.svg)](https://www.paypal.me/scobalula) ![Downloads](https://img.shields.io/github/downloads/Scobalula/CSVWeaponStatReader/total.svg) [![license](https://img.shields.io/github/license/Scobalula/CSVWeaponStatReader.svg)]()

<div style="text-align:center"><img src ="https://i.imgur.com/egtdqDo.png"/></div>

This tool will read CSV files with Call of Duty Weapon stats stored in them, specifically Marvel4's raw spreadsheets (i.e. with headers named the same as those used in APE/Asset Manager.) and save them to a GDT. I made this tool in less than a few hours but I hope it saves most people countless hours in copying stats from a raw spreadsheet.

# How to use

Use is simple, you can simply drag and drop onto the weapons box or click Open CSV to load a CSV. If the data is correct then the weapons will be loaded into the weapons box and Key/Values for weapon stats will be loaded into the Settings box.

The CSV files ***must*** be unformatted, with the column **WEAPONFILE** used as the name for "Weapons" box and matching APE/Asset Manager settings being used for saving, an example of how it should be formatted is like so:

| WEAPONFILE   | displayName | clipSize | damage | ..... |
|--------------|-------------|----------|--------|-------|
| h1_ak47_mp   | AK-47       | 30       | 40     |       |
| h1_aprast_mp | BOS14       | 35       | 35     |       |
| h1_g3_mp     | G3          | 20       | 40     |       |

And the CSV should appear like so when opened in text editor:

```
WEAPONFILE,displayName,clipSize,damage,....
h1_ak47_mp,AK-47,30,40,....
h1_aprast_mp,BOS14,35,45,....
h1_g3_mp,G3,20,40,....
```

To save a weapon simply select it, select the weapon type and click Save Selected, to save all select Save All (the Weapon Type is specific to each weapon so you can simply select it for each weapon then click Save All).

***NOTE:*** If you're using Marvel4's statsheets (which most people will), make sure to click the "***Raw Weapons***" tab and download as a ***CSV***, if a statsheet of his does not have a Raw Spreadsheet then those stats can't be used as it does not work with the other spread sheets with formatting, etc.

# Credits

* Collie (Suggesting it)
* Marvel4 (Raw Weapon Stats being the reason this was made that are on point)
* Amazing people of Stackoverflow (me still C# nublet)

# License

The tool is released under GPL 3.0 and is free to use and modify. The tool is provided with NO warranty at all, you retain full responsibility, I am not responsible for any damages. Please read the LICENSE file for more details.

# Donations

A lot of work is put into my tools, feel like buying me a drink? Click here:

[![Donate](https://img.shields.io/badge/Donate-PayPal-yellowgreen.svg)](https://www.paypal.me/scobalula) 

