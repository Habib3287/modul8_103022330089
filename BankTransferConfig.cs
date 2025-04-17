using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;


public class BankTransferConfig
{
    public string lang { get; set; }
    public List<String> methods { get; set; }
    public Transfer transfer { get; set; }
    public Confirmation confirmation { get; set; }
    public const String filePath = @"bank_transfer_config.json";
    public static bool isIntialized = false;

    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }

    public BankTransferConfig()
    {
        if (isIntialized) return;
        isIntialized = true;

        try
        {
            string readJson = File.ReadAllText(filePath);
            var config = JsonSerializer.Deserialize<BankTransferConfig>(readJson);
            lang = config.lang;
            methods = config.methods;
            transfer = config.transfer;
            confirmation = config.confirmation;
        }
        catch (Exception ex)
        {
            SetDefault();
            SaveConfig();
        }
    }

    private void SetDefault()
    {
        lang = "en";
        methods = new List<string> { "bank_transfer" };
        transfer = new Transfer
        {
            threshold = 25000000,
            low_fee = 6500,
            high_fee = 15000
        };
        confirmation = new Confirmation
        {
            en = "yes",
            id = "ya"
        };
    }

    private void SaveConfig()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(filePath, json);
    }

    public void ubahBahasa() { 
        if (lang.ToLower() == "en")
            lang = "id";
        else
            lang = "en";
        
        SaveConfig();
    }

}
