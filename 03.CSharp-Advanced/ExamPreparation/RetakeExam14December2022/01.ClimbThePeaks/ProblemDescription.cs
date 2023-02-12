//Alex is a vlogger and he wants to make videos, climbing the five highest peaks in Pirin mountain in just one week. He will take his video set, a tent and his backpack in the mountain. The backpack fits food portions for one week, exactly. His daily stamina is also limited. Your task is to trace his adventure and to create a post for his profile @alaroundtheworld, at the end of the journey.

//You will have to keep information for all the conquered peaks, if any.

//Every day, Alex will use one portion of his daily food supplies and will exhaust one of his daily stamina.

//First, you will be given a sequence of numbers, representing the quantities of the daily portions of food supplies in his backpack.
//Afterwards, you will be given another sequence of numbers, representing the quantities of the daily stamina he will have on his disposal for the next seven days.

//You have to sum the quantity of the last daily food portion with the quantity of the first daily stamina. He will start climbing from the first peak in the table below to the last one.
//· If the sum is equal or greater than the corresponding Mountain Peak’s Difficulty level from the table below, it means that the peak is conquered. In this case, you should remove both quantities from the sequences and continue with the next ones towards the next peak.
//· If the sum is less than the corresponding Mountain Peak’s Difficulty level from the table below, the peak remains unconquered. You should remove both quantities from the sequences. Alex will have to sleep in his tent. On the next day he will try the same peak once again.

//_____________________________________
//| Mountain Peaks | Difficulty level |
//|     Vihren     |         80       |
//|     Kutelo     |         90       |
//| Banski Suhodol |        100       |
//|    Polezhan    |         60       |
//|    Kamenitza   |         70       |
//‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾

//Alex will try to conquer as much peaks as he can in seven days. If he eats all the food supplies and exhausts all his stamina before the last day of his journey, the adventure is over. If he manages to climb all the peaks, the journey ends and the output is printed on the Console.

//Finally, print on the Console all the conquered peaks(in the order of climbing).

//Input
//· On the first line, you will receive the food portions quantities, separated by comma and a single space (', ').
//· On the second line, you will receive the stamina quantities, separated by comma and a single space (', ').

//Output
//· On the first line – print whether Alex managed to reach his goal and climb all the peaks in his list:
//o If he managed to conquer all: "Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK"
//o If he didn't manage to climb all of the peaks: "Alex failed! He has to organize his journey better next time -> @PIRINWINS"
//· Then, in either case, if Alex fails or succeed in completing the climbing adventure, you should print all conquered peaks (in the order of climbing), if there are any:
//"Conquered peaks:
//{ peak1}
//{ peak2}
//…
//{ peakn}
//"
//o If there are no conquered peaks do not print this message.

//Constraints
//· All of the given numbers will be valid integers in the range [0…100].
//· Do not use "\r\n" for a new line.