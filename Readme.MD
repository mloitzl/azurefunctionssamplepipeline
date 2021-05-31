# Introduction

- A sample Azure Functions Pipeline for
    - Receiving an Order ("OnOrderReceived")
    - Processing an Order ("ProcessOrder")
        - Create a License
        - Store the License in a Table
        - Add license to a send queue
    - Deliver the license as e-Mail ("DeliverLicense")

![Functions-Demo-Overview](img/Functions-Demo-Overview.png)

Created for a demo introduction for Azure Functions