TARGET = PS4NINJA

$(TARGET):
	cd ../../../minlib && $(MAKE) clean && $(MAKE)
	cd ../../../ps4ninja_ps4 && $(MAKE) clean && $(MAKE)
	cp ../../../ps4ninja_ps4/bin/ps4ninja_ps4 ../payload_176.bin
	
