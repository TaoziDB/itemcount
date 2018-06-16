http://www.thebuddyforum.com/demonbuddy-forum/plugins/158767-plugin-itemcount.html#post1477550

[PLUGIN] ItemCount
Author: Taozi

[NO LONGER WORKS, BECAUSE THERE IS NO MORE LIFETIME KEY, AND I DON'T WANT TO PAY FOR THE KEY YEARLY SINCE I STOPPED PLAYING DIABLO 3, GG]

What is ItemCount?
ItemCount is a plugin that will count items and list all items in Stash and Inventory,
New feature: will auto update item count every time game is joined or stash is opened.

How does it Work:

1. Enable ItemCount Plugin


2. Click ItemCount tab on Demonbuddy Menu


3. Item Count will be auto updated whenever game is joined or stash is opened, Please note that if you move mouse over item icon, you can find out the name of the item, this is especially useful for infernal machines, since all 4 infernal machines have exact same icons.
[CODE]"Khanduran Rune",
"Greater Rift Keystone",
"Death's Breath",
"Forgotten Soul",
"Veiled Crystal",
"Arcane Dust",
"Reusable Parts",
"Caldeum Nightshade",
"Arreat War Tapestry",
"Corrupted Angel Flesh",
"Westmarch Holy Water",
"Infernal Machine of Regret",
"Infernal Machine of Putridness",
"Infernal Machine of Terror",
"Infernal Machine of Fright",
"Ramaladni's Gift",
"Leoric's Regret",
"Vial of Putridness",
"Idol of Terror",
"Heart of Fright"
[/CODE]

4. Click Count Items button will count the following items in Stash and Inventory and show the result in ItemCount Tab, Demonbuddy log window and log file, to use this function, Your hero need to be in game and demonbuddy need to be Paused or Stopped
please note that your hero's location (In Town or Out of Town) doesn't matter, game mode (Campaign or Adventure) doesn't matter either

5. Click List Items button will list all items in Stash and Inventory with item Name and item ActorSNO, and show the result in Demonbuddy log window and log file, please note there might be a little delay, be patient
the following is an example result (abridged)
[CODE]2014-04-16 21:51:49,373 [1] INFO  Logger (null) - [ItemCount] Item Listing Starts
2014-04-16 21:51:49,426 [1] INFO  Logger (null) - [ItemCount] Plan: Fleeting Strap,192598
2014-04-16 21:51:49,492 [1] INFO  Logger (null) - [ItemCount] Pledge of Caldeum,196570
2014-04-16 21:51:49,561 [1] INFO  Logger (null) - [ItemCount] Reusable Parts,361984
2014-04-16 21:51:49,629 [1] INFO  Logger (null) - [ItemCount] Design: Amulet of Strength,192600
2014-04-16 21:51:49,693 [1] INFO  Logger (null) - [ItemCount] Reusable Parts,361984
2014-04-16 21:51:49,760 [1] INFO  Logger (null) - [ItemCount] Ascended Crown,253992
2014-04-16 21:51:49,826 [1] INFO  Logger (null) - [ItemCount] Ascended Crown,253992
.
.
.
2014-04-16 21:51:53,781 [1] INFO  Logger (null) - [ItemCount] Health Potion,304319
2014-04-16 21:51:53,848 [1] INFO  Logger (null) - [ItemCount] Health Potion,304319
2014-04-16 21:51:53,849 [1] INFO  Logger (null) - [ItemCount] Item Listing Is Done[/CODE]

6. After Counting or Listing, Click Open Log File button will open current log file for you to see the result.

7. [optional function], if you put <RunItemCount /> into your profile anywhere when the hero is in game, whenever profile run through that point, Item Count result will automatically show in ItemCount tab windows, Demonbuddy log window and log file, this is very helpful if you are looking for some item.

8. [optional function], if you put <RunItemLister /> into your profile anywhere when the hero is in game, whenever profile run through that point, Item Lister result will automatically show in Demonbuddy log window and log file, this is very helpful if you are looking for some item.

Thanks To
Mattdee for 7 item ActorSNOs
Taozi :) for 64 item ActorSNOs

Version History
ver 2.4.1: corrections for item name tooltips
ver 2.4.0: updated for Patch 2.4
ver 2.3.2: restore on-game-joined auto update function
ver 2.3.1: Due to conflict with nav server code in Beta 570, on-game-joined update is temporarily disabled, item counts will only be updated when stash is opened or count item button is pressed, I will try to figure out on-game-joined problem.
ver 2.3.0: updated for Patch 2.3, changed to a new SVN link
ver 2.2.0: updated for DemonbuddyBETA v1.1.2299.519
ver 2.1.0: added hellfire materials, updated xml tag.
ver 2.0.0: per popular request, item count now will be auto updated on game join or stash open.
ver 1.0.0: total UI change
ver 0.9.7: removed legendary crafting materials
ver 0.9.6: added staff of herding craft materials
ver 0.9.5: correct counting for non-stackable item (especially Horadric Cache)
ver 0.9.4: added ItemCount log window
ver 0.9.3: added all crafting materials
ver 0.9.2: small fix, now plugin can run in paused or stopped state
ver 0.9.1: small fix, now in order to use the plugin, the bot must be Stopped, will add usage for Paused as soon as I can figure out the way to check pause status and pause action.
ver 0.9.0: first public release.

