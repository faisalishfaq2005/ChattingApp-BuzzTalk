# 💬 ChattingApp — BuzzTalk

**BuzzTalk** is a modern Windows desktop chat application built with **C# (.NET Framework 4.7.2)** and **Windows Forms (WinForms)**.  
It allows users to **create contacts, send messages, form groups, assign group admins, share messages within groups, and build larger communities or channels** — all through a clean, interactive desktop interface.

The app is divided into two parts:  
1. A **WinForms-based frontend** that delivers an intuitive, multi-page user interface.  
2. A **reusable backend class library** that encapsulates the core domain logic, data-access abstractions, and utilities.

---

### 🧩 Highlights

- 🗣️ **Private Messaging** — Add contacts and chat one-on-one.  
- 👥 **Groups** — Create groups, add participants, assign group admins, and exchange messages collectively.  
- 🌐 **Communities** — Build and manage communities that host multiple groups or channels.  
- 📢 **Channels** — Broadcast messages and updates to subscribers.  
- ⚙️ **Settings Panel** — Manage preferences, add contacts, and customize your experience.  
- 🎨 **Modern UI** — Clean and responsive interface using **Guna.UI2** components and **FontAwesome** icons.

---

### 🏗️ Architecture Overview

A Windows desktop chat application built with .NET Framework 4.7.2 and Windows Forms (WinForms).  
The project is split into a **UI frontend** and a **reusable backend class library** encapsulating the domain model and data-access abstractions.

- **Frontend**: WinForms app with modern UI components (Guna.UI2, FontAwesome.Sharp) and multiple feature pages (chats, groups, communities, channels, settings, auth).  
- **Backend (Class Library)**: Domain models for users, messages, groups, communities, channels, and utility helpers. Includes data-layer interfaces and basic DB-layer stubs. Uses **ImageSharp** for image processing.

---

### 📁 Repository Structure

chatapp/
DLLFile-Backend/
DLLFileBackend/
BL/ # Domain (business) layer: Users, Messages, Groups, etc.
DL/ # Data layer (DB stubs), interfaces in DLInterfaces/
DLInterfaces/ # Abstractions for persisting entities
Utils/ # Utilities
DLLFileBackend.csproj # Backend class library (.NET 4.7.2)
packages.config # NuGet packages for backend
DLLFileBackend.sln

FrontEnd/
Frontend/
UI/ # WinForms UI: Chat, Settings, Auth, etc.
Utilities/ # UI helpers and common components
Frontend.csproj # WinForms app (.NET 4.7.2)
packages.config # NuGet packages for frontend
Frontend.sln


---

### ⚙️ Key Technologies

- **Platform**: .NET Framework 4.7.2  
- **UI Framework**: Windows Forms  
- **UI Libraries**: Guna.UI2.WinForms, FontAwesome.Sharp  
- **Serialization / JSON**: System.Text.Json  
- **Async primitives**: Microsoft.Bcl.AsyncInterfaces, System.Threading.Tasks.Extensions  
- **Utilities**: System.Memory, System.Numerics.Vectors, System.ValueTuple, System.Runtime.CompilerServices.Unsafe

---

### 🧑‍💻 Frontend Features (UI)

- **Authentication**: Sign in / Sign up forms  
- **Chats**: Individual and group chat pages, messages list, message composition  
- **Groups & Communities**: Create groups, assign admins, manage communities and view associated groups  
- **Channels**: Channel listing and posts pages  
- **Settings**: Add contacts, manage preferences, and configure groups  
- **Theming & Icons**: Modern controls (Guna.UI2) and icons (FontAwesome)

Entry point: `Program.cs` runs `SignInForm`.

---

### 🧠 Backend Library (Domain + Data Layers)

- **Domain (BL)**:  
  `User`, `Message`, `TextMessage`, `ImageMessage`, `AudioMessage`, `VedioMessage` (video),  
  `Group`, `Community`, `Channel`, `GroupMessage`, `Status`

- **Data Abstractions (DLInterfaces)**:  
  `IUserDL`, `IMessageDL`, `IGroupDL`, `ICommunityDL`, `IIndividualContactDL`

- **DB Stubs (DL/DB)**:  
  Basic persistence classes for storing and retrieving domain entities — easily extendable to real databases.

- **Utilities**:  
  Common helpers and image processing with **ImageSharp**.

---

