To add a new receipt format: 
1. Add the format to ReceiptType enum
2. Implement the format in a class that implements IReceipt and optionally inherits from ReceiptBase
3. Add a new switch case to the ReceiptFactory