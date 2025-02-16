Good day fellow adventurer! I am Sir Quacks-A-Lot (*quack*). How may I help you on this lovely day? -> intro

== intro ==

 + [What are you doing here?]
    I am the protector of this bridge! -> evilDuckMentioned
 + [Can you tell me about this "evil duck"?]
    AH! -> evilDuckMentioned
 * [Why are you wearing a helmet?]
    It is a sign of my spotless (*quack*) reputation! I wear it for honor, glory, and God! -> intro
 + [May I pass you and go on the bridge?]
    Absolutely not (*quack*), unless you fight me! Otherwise, you shall be utterly disgraced. Though, you do not seem very strong (*quack*) or the fighting type, so I challenge you to a battle of wits! -> battleOfWits
    
== evilDuckMentioned ==

I have been on a wild duck (*quack*) chase in search of the evil, murderous, duck! But alas, I cannot find them, and because of this, I have not slept one wink (*quack*), in a fortnight!

+ [Is there any way I can help you?]
    Alas, no there is no way you can help me. Even if I needed the help, I could subject a fair citizen such as you to the horrors of the evil duck.
        I am bored however, so I challenge you to a battle of wits! -> battleOfWits
    

-> END

== battleOfWits ==

+ [Accept the challenge]
    -> question1
    
+ [No thanks]
    Disgraced (*quack*) you shall be then!
    -> END
    
== question1 ==
What goes up but never comes down? (*quack*)
* [Your age?]
    -> question2
* [Stairs?]
    -> disgraced
* [A balloon?]
     -> disgraced

== question2 ==
Correct! Onto the second (*quack*) question. The more you take, the more you leave behind. What are they?
* [Shadows?]
    -> disgraced
* [Footsteps?]
    -> question3
* [Coins?]
     -> disgraced

== question3 ==
Correct! Onto the last question. I have branches (*quack*), but no fruit, trunk or leaves. What am I?
* [A tree?]
    -> disgraced
* [A library?]
    -> disgraced
* [A bank?]
     -> win


== disgraced ==
Wrong! Disgraced (*quack*) you shall be then!
-> END

== win ==
Correct! (*quack*) Thank you for accepting my challenge to a battle of wits (*quack*). I will now allow you to pass through this bridge whenever you wish.

    -> END
