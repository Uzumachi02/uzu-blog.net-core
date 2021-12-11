// Example: dotnet fsi .\createMigrate.fsx [FILENAME]

open System
open System.IO

let args = Environment.GetCommandLineArgs()
let now = DateTime.Now
let filename = now.ToString("yyyyMMddHHmmss")

File.Create($"{filename}_{args.[2]}.sql")