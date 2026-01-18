# 🎓 Student Wallet – .NET MAUI MVP (Hackathon Demo)

> **Format:** Markdown (.md)
> **Namena:** Copy–paste dokument za Cursor (korak po korak implementacija)
> **Cilj:** Stabilan, minimalistički MVP sa mock funkcionalnostima, spreman za hackathon odbranu

---

## ⚠️ GLOBALNA PRAVILA (OBAVEZNO PROČITATI PRE IMPLEMENTACIJE)

Ovo je **DEMO / MVP aplikacija** za hackathon.

* ❌ NEMA pravog backend-a
* ❌ NEMA pravih plaćanja
* ❌ NEMA validacija
* ❌ NEMA async/await logike
* ❌ NEMA error handling-a

Sve funkcionalnosti su **MOCK** i služe isključivo za demonstraciju toka korisnika i digitalizacije procesa.

**Pravila za Cursor:**

* ❌ Ne dodavati fajlove koji nisu eksplicitno navedeni
* ❌ Ne menjati postojeće fajlove osim ako je jasno navedeno
* ✅ Svaki korak je izolovan
* ✅ Sve je sinhrono i jednostavno

---

## FAZA 0 – KREIRANJE PROJEKTA (RUČNO)

U Visual Studio:

* Template: **.NET MAUI App**
* Name: **StudentWalletApp**
* Framework: **.NET 8**
* Template type: **Shell**

👉 Ne menjati ništa dalje.

---

## FAZA 1 – STRUKTURA FOLDERA

### Prompt #1

```
Create the following folders in the project root:

- Models
- Services
- ViewModels
- Views

Do not add any files yet.
Do not modify existing files.
```

---

## FAZA 2 – MODELI (SAMO PODACI, BEZ LOGIKE)

### Prompt #2 – Student

```
Create Models/Student.cs.

Define a public class Student with only auto-properties:
- Guid Id
- string FullName
- string StudentNumber
- string Faculty

No methods.
No logic.
```

---

### Prompt #3 – Wallet

```
Create Models/Wallet.cs.

Define a public class Wallet with:
- decimal Balance
```

---

### Prompt #4 – Transaction

```
Create Models/Transaction.cs.

Define a public class Transaction with:
- Guid Id
- decimal Amount
- DateTime Date
- string Description
```

> Positive Amount = uplata
> Negative Amount = plaćanje

---

## FAZA 3 – MOCK SERVICE SLOJ

### Prompt #5 – Auth Service Interface

```
Create Services/IAuthService.cs.

Define an interface with:
- Student Login(string studentNumber)
- void Logout()
- Student GetCurrentStudent()
```

---

### Prompt #6 – MockAuthService

```
Create Services/MockAuthService.cs.

Implement IAuthService.

Behavior:
- Use a private Student field
- Login always returns a hardcoded Student
- No validation
- No database
```

---

### Prompt #7 – Wallet Service Interface

```
Create Services/IWalletService.cs.

Define:
- decimal GetBalance()
- void TopUp(decimal amount)
- bool Pay(decimal amount)
```

---

### Prompt #8 – MockWalletService

```
Create Services/MockWalletService.cs.

Implement IWalletService.

Behavior:
- Keep a private Wallet instance
- Initial balance = 5000
- Pay returns false if balance is insufficient
- No external dependencies
```

---

### Prompt #9 – Transaction Service Interface

```
Create Services/ITransactionService.cs.

Define:
- List<Transaction> GetTransactions()
- void AddTransaction(Transaction transaction)
```

---

### Prompt #10 – MockTransactionService

```
Create Services/MockTransactionService.cs.

Implement ITransactionService.

Behavior:
- Use in-memory List<Transaction>
- Seed with 2 example transactions
```

---

## FAZA 4 – BASE VIEWMODEL

### Prompt #11

```
Create ViewModels/BaseViewModel.cs.

Implement INotifyPropertyChanged.

Include:
- bool IsBusy
- string Title
- protected OnPropertyChanged method
```

---

## FAZA 5 – LOGIN

### Prompt #12 – LoginViewModel

```
Create ViewModels/LoginViewModel.cs.

Inherit BaseViewModel.

Properties:
- string StudentNumber

Command:
- LoginCommand

Behavior:
- Call MockAuthService.Login
- Navigate to HomeView using Shell navigation
```

---

### Prompt #13 – LoginView (XAML)

```
Create Views/LoginView.xaml.

UI:
- VerticalStackLayout
- Entry bound to StudentNumber
- Button bound to LoginCommand

No styling.
Minimal layout.
```

---

### Prompt #14 – LoginView Code-behind

```
Create Views/LoginView.xaml.cs.

Set BindingContext to LoginViewModel.
Do not add logic.
```

---

## FAZA 6 – HOME (DASHBOARD)

### Prompt #15 – HomeViewModel

```
Create ViewModels/HomeViewModel.cs.

Properties:
- string StudentName
- string Faculty
- decimal Balance

Commands:
- GoToTopUpCommand
- GoToCanteenCommand
- GoToDormCommand
- GoToActivateCardCommand
- GoToImportCardCommand
- GoToLaundryCommand
- GoToPartyCommand
- GoToTransactionsCommand

Load data in constructor.
```

---

### Prompt #16 – HomeView

```
Create Views/HomeView.xaml.

UI:
- Label for StudentName
- Label for Faculty
- Label for Balance

Buttons for each command.

Use VerticalStackLayout.
```

---

## FAZA 7 – PLAĆANJA (UPLATA / MENZA / DOM)

Za **TopUp**, **Menza**, **Dom**:

Svaki ekran ima:

* ViewModel
* View
* Code-behind

Zajednička logika:

* Entry za iznos
* Button za potvrdu
* Ažurira Wallet
* Dodaje Transaction

---

## FAZA 8 – AKTIVACIJA I IMPORT KARTICE (MOCK)

### Activate Card

```
Create ActivateCardView.

UI:
- Button "Activate Card"

On click:
- Display alert "Card activated successfully (demo)"
```

---

### Import Card

```
Create ImportCardView.

UI:
- Button "Import Card"

On click:
- Display alert "Card linked to account (demo)"
```

---

## FAZA 9 – ZAKAZIVANJE PRANJA VEŠA

```
Create LaundryView.

UI:
- Picker with time slots
- Button "Schedule"

On click:
- Display alert "Laundry scheduled successfully"
```

---

## FAZA 10 – ZAKAZIVANJE ŽURKE (PORTIR – DEMO)

### PartyViewModel

```
Create ViewModels/PartyViewModel.cs.

Properties:
- DateTime PartyDate
- string RoomNumber
- TimeSpan PartyTime

Command:
- SchedulePartyCommand
```

---

### PartyView

```
Create Views/PartyView.xaml.

UI:
- DatePicker for PartyDate
- Entry for RoomNumber
- TimePicker for PartyTime
- Button "Schedule Party"

On click:
- Display alert:
  "Party scheduled successfully.
   Porter has been notified (demo)."
```

⚠️ Nema realnih notifikacija
⚠️ Nema backend-a
⚠️ Samo UI simulacija

---

## FAZA 11 – ISTORIJA TRANSAKCIJA

```
Create TransactionsView.

UI:
- ListView or CollectionView
- Bind to list of Transaction
- Show Date, Description, Amount
```

---

## FAZA 12 – SHELL NAVIGACIJA

### Final Prompt

```
Modify AppShell.xaml.

Register routes for:
- LoginView
- HomeView
- TopUpView
- DormPaymentView
- CanteenView
- ActivateCardView
- ImportCardView
- LaundryView
- PartyView
- TransactionsView

Set LoginView as startup page.

Do not modify anything else.
```

---

## 🎯 ŠTA OVAJ MVP DEMONSTRIRA

* Digitalizaciju studentskih plaćanja
* Centralizovan studentski novčanik
* Uklanjanje fizičkog odlaska do blagajne
* Proširiv sistem (pranje, događaji, usluge)

---

## 🚀 IDEJE ZA DALJI RAZVOJ (NE IMPLEMENTIRATI)

* Automatske mesečne uplate doma
* Push notifikacije
* QR / NFC plaćanja
* Digitalna studentska legitimacija
* Integracija sa bibliotekama i menzama

---

## 🏁 ZAKLJUČAK

Ovaj dokument omogućava:

* stabilnu implementaciju u kratkom roku
* kontrolu nad Cursor-om
* jak MVP za hackathon prezentaciju

**Sve dugmiće “rade”, ali bez rizika.**

---
