// This is a tool designed to extend the "linux terminal" and "command shell | wsl"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// function headers
void print();

// constants
#define RESET "\x1B[0m"

// main()
int main (int argc, char *argv[]) {

	// parse out the flag
	int i, asciiFlag;
	for (i = 0; i < argc; i++) {
	   	if (i == 1) {
			char flag[strlen(argv[i]) + 1];
			strcpy(flag, argv[i]);
			asciiFlag = flag[1];
			//printf("%d\n", asciiFlag); // displays ascii code for the flag
	   }
	}

	// parse out a windows pipe into WSL
//	char ending[strlen(argv[0]) + 1];
//	strcpy(ending, argv[0]);
//	printf("%c", ending[strlen(ending) + 1]);

	// check the first argument
	if (argc == 1) {// || (int)ending[strlen(ending) + 1] == 0) {
	   	print();
	} else if (argc == 2) {

	   	//if (strcmp(argv[1], "-help") == 0) { // old code, trying to allow command with no flags
	   	if (asciiFlag == 102) { // flag -f
	   	//} else if (strcmp(argv[1], "-f") == 0) { // old code, trying to allow command with no flags
			printf("Hello\n");
	   	} else if (asciiFlag == 108) { // flag -l
	   	//} else if (strcmp(argv[1], "-l") == 0) { // old code, trying to allow command with no flags
			printf("World\n");
	   	} else if (asciiFlag == 119) { // flag -w
	   	//} else if (strcmp(argv[1], "-l") == 0) { // old code, trying to allow command with no flags
			print();
    	} else if (asciiFlag == 104) { // flag -h <--- help table

	    	// display header for help table
			printf("\n   \x1B[36m%s", argv[0]);
			printf(RESET);
	
			// display the -f flag
						  printf(" has the following flags:\n");
			printf("╘═══════════════════════════════════════╛\n");
			printf("   \x1B[36m-f" RESET);
	
			// display the -l flag
				 		 printf("\tdisplays \"Hello\"\n");
			printf("   \x1B[36m-l" RESET);
				 		 printf("\tdisplays \"World\"\n");
			
			// add padding
			printf("\n\n");
	
			// display the -w flag info
			printf("╭───────────────────────────────────────╮\n");
			printf("|  \x1B[36m-w" RESET);
						 printf("\tuse when \"\x1B[32mecho %s|wsl", argv[0]);
			printf(RESET);
													     printf("\"\t|\n");//, argv[0]);
			printf("╰───────────────────────────────────────╯\n");

	   	} else {
			printf("Error: flags not recognized, type -h flag for more information.\n");
	   	}
	} else {
		printf("Error: too many arguments.\n");
	}
 return 0;
} // end main()

void print() {
	printf("Hello World\n");
}