package com.bv.eidss.model;

import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteStatement;

import com.bv.eidss.data.EidssDatabase;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import java.io.IOException;
import java.util.ArrayList;

//
// Created by Vdovin on 09.05.2015.
//
public class FFReferences {
    public ArrayList<FFTemplateElement> templatesVector = new ArrayList<>();
    public ArrayList<FFDeterminant> determinantsVector = new ArrayList<>();
    public ArrayList<FFRule> rulesVector = new ArrayList<>();
    public ArrayList<FFRuleConstant> ruleConstantsVector = new ArrayList<>();
    public ArrayList<FFParameterForFunction> parameterForFunctionsVector = new ArrayList<>();
    public ArrayList<FFParameterForAction> parameterForActionsVector = new ArrayList<>();
    public ArrayList<FFParameterFixedPresetValue> parameterFixedPresetValueVector = new ArrayList<>();
    public ArrayList<Long> referenceTypes = new ArrayList<>();

    public FFReferences(JSONObject json) throws JSONException {
        JSONArray templates = json.getJSONArray("templates");
        JSONArray determinants = json.getJSONArray("determinants");
        JSONArray rules = json.getJSONArray("rules");
        JSONArray constants = json.getJSONArray("constants");
        JSONArray funcpars = json.getJSONArray("funcpars");
        JSONArray actpars = json.getJSONArray("actpars");
        JSONArray pfpvals = json.getJSONArray("pfpvals");
        JSONArray rftypes = json.getJSONArray("rftypes");

        for (int i = 0; i < templates.length(); i++) {
            templatesVector.add(new FFTemplateElement(templates.getJSONObject(i)));
        }
        for (int i = 0; i < determinants.length(); i++) {
            determinantsVector.add(new FFDeterminant(determinants.getJSONObject(i)));
        }
        for (int i = 0; i < rules.length(); i++) {
            rulesVector.add(new FFRule(rules.getJSONObject(i)));
        }
        for (int i = 0; i < constants.length(); i++) {
            ruleConstantsVector.add(new FFRuleConstant(constants.getJSONObject(i)));
        }
        for (int i = 0; i < funcpars.length(); i++) {
            parameterForFunctionsVector.add(new FFParameterForFunction(funcpars.getJSONObject(i)));
        }
        for (int i = 0; i < actpars.length(); i++) {
            parameterForActionsVector.add(new FFParameterForAction(actpars.getJSONObject(i)));
        }
        for (int i = 0; i < pfpvals.length(); i++) {
            parameterFixedPresetValueVector.add(new FFParameterFixedPresetValue(pfpvals.getJSONObject(i)));
        }
        for (int i = 0; i < rftypes.length(); i++) {
            JSONObject js = rftypes.getJSONObject(i);
            referenceTypes.add(js.getLong("id"));
        }
    }

    public FFReferences(XmlPullParser parser) throws XmlPullParserException, IOException {
        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("tems")){
                        templatesVector = FFTemplateElement.FromXml(parser);
                    }
                    else if (name.equalsIgnoreCase("dets")){
                        determinantsVector = FFDeterminant.FromXml(parser);
                    }
                    else if (name.equalsIgnoreCase("ruls")){
                        rulesVector = FFRule.FromXml(parser);
                    }
                    else if (name.equalsIgnoreCase("cons")){
                        ruleConstantsVector = FFRuleConstant.FromXml(parser);
                    }
                    else if (name.equalsIgnoreCase("funs")){
                        parameterForFunctionsVector = FFParameterForFunction.FromXml(parser);
                    }
                    else if (name.equalsIgnoreCase("acts")){
                        parameterForActionsVector = FFParameterForAction.FromXml(parser);
                    }
                    else if (name.equalsIgnoreCase("pfps")){
                        parameterFixedPresetValueVector = FFParameterFixedPresetValue.FromXml(parser);
                    }
                    else if (name.equalsIgnoreCase("rfts")){
                        referenceTypes = parseReferenceTypes(parser);
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("ff")){
                        return;
                    }
                    break;
            }
            eventType = parser.next();
        }

    }

    private static ArrayList<Long> parseReferenceTypes(XmlPullParser parser) throws XmlPullParserException, IOException{
        ArrayList<Long> ref = new ArrayList<>();

        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("obj")){
                        long r = Long.parseLong(parser.getAttributeValue("", "id"));
                        ref.add(r);
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("rfts")){
                        return ref;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return ref;
    }

    public void Update(SQLiteDatabase db){
        db.delete("FFTemplate", null, null);
        db.delete("FFDeterminant", null, null);
        db.delete("FFRule", null, null);
        db.delete("FFRuleConstant", null, null);
        db.delete("FFParameterForFunction", null, null);
        db.delete("FFParameterForAction", null, null);
        db.delete("FFParameterFixedPresetValue", null, null);

        SQLiteStatement stmt = db.compileStatement(EidssDatabase.insert_sql_ff_template_elements);
        for (FFTemplateElement tv : templatesVector) {
            stmt.clearBindings();
            stmt.bindLong(1, tv.idfsBaseReference);
            stmt.bindLong(2, tv.idfsFormTemplate);
            stmt.bindLong(3, tv.idfsBaseReferenceParent);
            stmt.bindLong(4, tv.intElementType);
            stmt.bindLong(5, tv.idfsEditor);
            stmt.bindLong(6, tv.intReadOnly);
            stmt.bindLong(7, tv.intMandatory);
            stmt.bindLong(8, tv.idfsParameterType);
            stmt.bindLong(9, tv.intOrder);
            stmt.bindLong(10, tv.idfsParameterCaption);
            stmt.executeInsert();
            //db.insert("FFTemplate", null, tv.ContentValues());
        }
        stmt.close();

        stmt = db.compileStatement(EidssDatabase.insert_sql_ff_determinants);
        for (FFDeterminant dv : determinantsVector) {
            stmt.clearBindings();
            stmt.bindLong(1, dv.idfDeterminantValue);
            stmt.bindLong(2, dv.idfsFormType);
            stmt.bindLong(3, dv.idfsFormTemplate);
            stmt.executeInsert();

            //db.insert("FFDeterminant", null, dv.ContentValues());
        }
        stmt.close();

        stmt = db.compileStatement(EidssDatabase.insert_sql_ff_rules);
        for (FFRule rv : rulesVector) {
            stmt.clearBindings();
            stmt.bindLong(1, rv.idfsRule);
            stmt.bindLong(2, rv.idfsFormTemplate);
            stmt.bindLong(3, rv.idfsCheckPoint);
            stmt.bindLong(4, rv.idfsRuleMessage);
            stmt.bindLong(5, rv.idfsRuleFunction);
            stmt.bindLong(6, rv.intNot);
            stmt.executeInsert();

            //db.insert("FFRule", null, rv.ContentValues());
        }
        stmt.close();

        stmt = db.compileStatement(EidssDatabase.insert_sql_ff_constants);
        for (FFRuleConstant rc : ruleConstantsVector) {
            stmt.clearBindings();
            stmt.bindLong(1, rc.idfsRule);
            stmt.bindString(2, rc.strConstant);
            stmt.executeInsert();

            //db.insert("FFRuleConstant", null, rc.ContentValues());
        }
        stmt.close();

        stmt = db.compileStatement(EidssDatabase.insert_sql_ff_parsforf);
        for (FFParameterForFunction pf : parameterForFunctionsVector) {
            stmt.clearBindings();
            stmt.bindLong(1, pf.idfsParameter);
            stmt.bindLong(2, pf.idfsRule);
            stmt.bindLong(3, pf.intOrder);
            stmt.executeInsert();

            //db.insert("FFParameterForFunction", null, pf.ContentValues());
        }
        stmt.close();

        stmt = db.compileStatement(EidssDatabase.insert_sql_ff_parsfora);
        for (FFParameterForAction pa : parameterForActionsVector) {
            stmt.clearBindings();
            stmt.bindLong(1, pa.idfsParameter);
            stmt.bindLong(2, pa.idfsRule);
            stmt.bindLong(3, pa.idfsRuleAction);
            stmt.executeInsert();

            //db.insert("FFParameterForAction", null, pa.ContentValues());
        }
        stmt.close();

        stmt = db.compileStatement(EidssDatabase.insert_sql_ff_parsprefixed);
        for (FFParameterFixedPresetValue pp : parameterFixedPresetValueVector) {
            stmt.clearBindings();
            stmt.bindLong(1, pp.idfsParameterFixedPresetValue);
            stmt.bindLong(2, pp.idfsParameterType);
            stmt.executeInsert();

            //db.insert("FFParameterFixedPresetValue", null, pp.ContentValues());
        }
        stmt.close();
    }
}
