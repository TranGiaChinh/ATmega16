# 🚀 ATmega16 UART Communication (Proteus Simulation)

**Description:**  
This project simulates UART communication between a computer and an ATmega16 microcontroller using Proteus. Additionally, a user interface is developed using Visual Studio Code.

## 📌 Key Features
- Simulates serial (UART) communication between ATmega16 and a computer.
- Uses **Proteus** for circuit design and simulation.
- **Virtual Terminal** in Proteus is used to monitor data transmission.
- Provides a user-friendly **GUI** built with Visual Studio Code.

### Required Software
- **Proteus 8** or later.
- **AVR-GCC** for compiling the source code.
- **Virtual Serial Terminal** in Proteus to simulate UART communication.
- **Visual Studio Code** for running the GUI.

### Steps to Simulate
1. Open the **ATmega16.pdsprj** file in Proteus.
2. Ensure the UART settings are configured as **9600 Baud, 8N1**.
3. Compile the source code using **AVR-GCC** and generate a HEX file:
   ```sh
   avr-gcc -mmcu=atmega16 -o main.elf main.c
   avr-objcopy -O ihex main.elf main.hex
   ```
4. Load the **main.hex** file into ATmega16 in Proteus.
5. Run the simulation and observe the data on the **Virtual Terminal**.

## 📌 Expected Results
- When data is sent from the computer, ATmega16 will respond accordingly.
- Data exchange can be monitored through the **Virtual Terminal** in Proteus.
- The GUI provides an easy way to send and receive data.


